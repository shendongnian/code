    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.ObjectModel;
    
    namespace System
    {
        public static class StringExtensions
        {
            public static string[] Split(this string s, string delimiter)
            {
                return s.Split(new string[] { delimiter }, StringSplitOptions.None);
            }
    	}
    }
