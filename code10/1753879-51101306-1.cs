    namespace SO51101306
    {
        public static class IMappingExpressionExtensions
        {
            public static IMappingExpression<A, B> RegisterChainOfTypes<A, B>(this IMappingExpression<A, B> mapping)
            {
                mapping.BeforeMap((a, b, ctx) => {
                    ctx.PushTypeInChainOfTypes(typeof(A));
                });
    
                mapping.AfterMap((a, b, ctx) => {
                    ctx.PopLastTypeInChainOfTypes();
                });
                return mapping;
            }
        }
    
        public static class ResolutionContextExtensions
        {
            const string chainOfTypesKey = "ChainOfTypes";
    
            private static Stack<Type> GetOrCreateChainOfTypesStack(ResolutionContext ctx)
            {
                var hasKey = ctx.Items.ContainsKey(chainOfTypesKey);
                return hasKey ? (Stack<Type>)ctx.Items[chainOfTypesKey] : new Stack<Type>();
            }
    
            public static void PushTypeInChainOfTypes(this ResolutionContext ctx, Type type)
            {
                var stack = GetOrCreateChainOfTypesStack(ctx);
                stack.Push(type);
                ctx.Items[chainOfTypesKey] = stack;
            }
    
            public static Type PopLastTypeInChainOfTypes(this ResolutionContext ctx)
            {
                var stack = (Stack<Type>)ctx.Items[chainOfTypesKey];
                return stack.Pop();
            }
    
            public static bool HasParentType(this ResolutionContext ctx, Type parentType)
            {
                var stack = GetOrCreateChainOfTypesStack(ctx);
                return stack.Contains(parentType);
            }
    
        }
    
        public class CarCopyProfile : Profile
        {
            public CarCopyProfile()
            {
                CreateMap<CarA, CarB>().RegisterChainOfTypes();
                CreateMap<BoatA, BoatB>().RegisterChainOfTypes();
    
                CreateMap<WindshieldA, WindshieldB>()
                .ConvertUsing((wa,wb,ctx)=> {
                    if(ctx.HasParentType(typeof(CarA)))
                    {
                        Console.WriteLine("I'm coming from CarA");
                        //Do specific stuff here
                    }
                    else if (ctx.HasParentType(typeof(BoatA)))
                    {
                        Console.WriteLine("I'm coming from boatA");
                        //Do specific stuff here
                    }
                    return wb;
                });
    
            }
        }
    
        public class CarA
        {
            public WindshieldA Windshield { get; set; }
        }
    
        public class BoatA
        {
            public WindshieldA Windshield { get; set; }
        }
    
        public class CarB
        {
            public WindshieldB Windshield { get; set; }
        }
    
        public class BoatB
        {
            public WindshieldB Windshield { get; set; }
        }
    
        public class WindshieldA
        {
            public string Name { get; set; }
        }
    
        public class WindshieldB
        {
            public string Name { get; set; }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Mapper.Initialize(c => c.AddProfile<CarCopyProfile>());
    
                var carA = new CarA{Windshield = new WindshieldA()};
                var boatA = new BoatA{Windshield = new WindshieldA()};
    
                var carB = Mapper.Map<CarB>(carA);
                var boatB = Mapper.Map<BoatB>(boatA);
            }
        }
    }
