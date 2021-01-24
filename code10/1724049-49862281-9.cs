    var dictionary = new Dictionary<Type, Action>
        {
            {
                typeof(GrenadeSkillEvent), () => 
                {
                }
            },
            {
                typeof(OtherSkillEvent), () => 
                {
                
                }
            }
        }
    dictionary[@event.GetType()]();
