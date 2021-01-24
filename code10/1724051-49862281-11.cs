    if (@event == null)
    {
        //null handling
    }
    var dictionary = new Dictionary<Type, Action>
        {
            {
                typeof(GrenadeSkillEvent), () => 
                {
                    //some logic
                }
            },
            {
                typeof(OtherSkillEvent), () => 
                {
                    //some logic
                }
            }
        }
    dictionary[@event.GetType()]();
