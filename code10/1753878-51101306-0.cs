    public CarCopyProfile()
    {
        this.CreateMap<CarA, CarB>()
            .BeforeMap((a,b,ctx) => {
                ctx.Items.Add("parentType", a.GetType());
            });
        this.CreateMap<BoatA, BoatB>()
            .BeforeMap((a, b, ctx) => {
                ctx.Items.Add("parentType", a.GetType());
            });
    
        this.CreateMap<WindshieldA, WindshieldB>()
        .ConvertUsing((wa,wb,ctx)=> {
            var parentType = ctx.Items["parentType"] as Type;
            Console.WriteLine($"I'm coming from {parentType.FullName}");
            return wb;
        });
    }
