    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestProject1
    {
        class Class1
        {
        static public string cstr_to_string( byte[] data, int code_page)
        {
            Encoding Enc = Encoding.GetEncoding(code_page);  
            int inx = Array.FindIndex(data, 0, (x) => x == 0);//search for 0
            if (inx >= 0)
              return (Enc.GetString(data, 0, inx));
            else 
              return (Enc.GetString(data)); 
        }
    
        }
    }
