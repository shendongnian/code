                int? a;
                a = null;
                //Convert null to boolean
                bool a1 = Convert.ToBoolean(a);
                Console.WriteLine("Null Value - " + a1);
                a = 1;
                //Convert integer value to boolean
                a1 = Convert.ToBoolean(a);
                Console.WriteLine("Have Value - " + a1);
                var srcClass = new SourceClass { Value1 = null, Value2 = 1, Value3 = 20 };
                Mapper.Initialize(cfg =>
                {
                    cfg.RecognizeDestinationPostfixes("IsNull");
                    cfg.CreateMap<SourceClass, TargetClass>();
                });
                var targetClass = Mapper.Map<SourceClass, TargetClass>(srcClass);
                Console.WriteLine(targetClass.Value1IsNull+" - " +targetClass.Value2IsNull+" - " +targetClass.Value3IsNull);  
