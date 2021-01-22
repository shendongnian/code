    public class Form1 
    { 
    
    private void main() 
    { 
        MyCommandHandler CommandLineHandler = new MyCommandHandler(); 
        CommandLineHandler.SetInput = "-t alpha 1 -prod 1 2 -sleep 200"; 
        
        //now we can use strong name to work with the variables: 
        //CommandLineHandler.prod.ProdID 
        //CommandLineHandler.prod.ProdInstanceID 
        //CommandLineHandler.Alpha.AlhaValue() 
        //CommandLineHandler.Sleep.Miliseconds() 
        if (CommandLineHandler.Alpha.AlhaValue > 255) { 
            throw new Exception("Apha value out of bounds!"); 
        } 
        
    } 
    } 
    public class MyCommandHandler 
    { 
    private string[] values; 
    public string SetInput { 
        set { values = Strings.Split(value, "-"); } 
    } 
    
    //Handle Prod command 
    public struct prodstructure 
    { 
        public string ProdID; 
        public string ProdInstanceID; 
    } 
    public prodstructure prod { 
        get { 
            prodstructure ret = new prodstructure(); 
            ret.ProdID = GetArgsForCommand("prod", 0); 
            ret.ProdInstanceID = GetArgsForCommand("prod", 1); 
            return ret; 
        } 
    } 
    
    //Handle Apha command 
    public struct Aphastructure 
    { 
        public int AlhaValue; 
    } 
    public Aphastructure Alpha { 
        get { 
            Aphastructure ret = new Aphastructure(); 
            ret.AlhaValue = Convert.ToInt32(GetArgsForCommand("alpha", 0)); 
            return ret; 
        } 
    } 
    
    
    //Handle Sleep command 
    public struct SleepStructure 
    { 
        public int Miliseconds; 
    } 
    public SleepStructure Sleep { 
        get { 
            SleepStructure ret = new SleepStructure(); 
            ret.Miliseconds = Convert.ToInt32(GetArgsForCommand("sleep", 0)); 
            return ret; 
        } 
    } 
    
    
    private string GetArgsForCommand(string key, int item) 
    { 
        foreach (string c in values) { 
            foreach (string cc in Strings.Split(c.Trim, " ")) { 
                if (cc.ToLower == key.ToLower) { 
                    try { 
                        return Strings.Split(c.Trim, " ")(item + 1); 
                    } 
                    catch (Exception ex) { 
                        return ""; 
                    } 
                } 
            } 
        } 
        return ""; 
    } 
    } 
