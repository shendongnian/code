    class Base 
    { 
        public virtual void Print() 
        { 
            Console.WriteLine("Base"); 
        } 
    } 
 
    class Der1 : Base 
    { 
        // omitting 'new' and using override here will override Base
        public override void Print() 
        { 
            Console.WriteLine("Der1"); 
        } 
    } 
