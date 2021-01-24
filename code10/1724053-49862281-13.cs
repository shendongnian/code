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
    if (@event == null)
    {
        //null handling
    }
    dictionary[@event.GetType()]();
