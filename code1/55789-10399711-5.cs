    using System.Web.Security;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq.Expressions;
    using System.Web.Routing;
    using System.Web.Helpers;
    using System.Web.Mvc.Html;
    using MvcHtmlHelpers;
    using System.Linq;
    
    namespace EzPL8.Models   
    {
        public class MyEggs
        {
            public Dictionary<int, string> Egg { get; set; }
            public MyEggs()  //constructor
            {
                Egg = new Dictionary<int, string>()
                {
                    { 0, "No Preference"},
                    { 1, "I hate eggs"},
                    { 2, "Over Easy"},
                    { 3, "Sunny Side Up"},
                    { 4, "Scrambled"},
                    { 5, "Hard Boiled"},
                    { 6, "Eggs Benedict"}
                };
        }
    }
