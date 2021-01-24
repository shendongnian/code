    var dictionary = new Dictionary<Type, Action>
        {
            {
                typeof(GrenadeSkillEvent), () => 
                {
                    float grenadeParam = ((GrenadeSkillEvent)@event).grenadeParam;
                    //some logic
                }
            },
            {
                typeof(OtherSkillEvent), () => 
                {
                    string stringParam = ((OtherSkillEvent)@event).stringParam;
                    //some logic
                }
            }
        }
    if (@event == null)
    {
        //null handling
    }
    dictionary[@event.GetType()]();
