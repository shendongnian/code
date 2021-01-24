    var dictionary = new Dictionary<Type, Action<SkillEvent>>
        {
            {
                typeof(GrenadeSkillEvent), e => 
                {
                    float grenadeParam = ((GrenadeSkillEvent)e).grenadeParam;
                    //some logic
                }
            },
            {
                typeof(OtherSkillEvent), e => 
                {
                    string stringParam = ((OtherSkillEvent)e).stringParam;
                    //some logic
                }
            }
        }
    if (@event == null)
    {
        //null handling
    }
    else
    {
        dictionary[@event.GetType()](@event);
    }
