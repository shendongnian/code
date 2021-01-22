    public delegate string SD();//declare before class definition
    string X = GetValue(() => Message.instance[0].prop1.prop2.ID); //usage
    //GetValue defintion
    private string GetValue(SD d){
            try
            {
                return d();
            }
            catch (NullReferenceException) {
                return "";
            }
    
        }
