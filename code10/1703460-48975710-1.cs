            var cp = GetMemberNames<Model1, Model2>(new[] 
                        { nameof(Model1.Common1),   
                          nameof(Model2.Common2), 
                          nameof(Model1.Prop11), 
                          nameof(Model2.Prop21),
                          "SomeUnknownProperty", 
                        });
