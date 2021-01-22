    using System.Web.Security;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq.Expressions;
    using System.Web.Routing;
    using System.Web.Helpers;
    using System.Web.Mvc.Html;
    using MvcHtmlHelpers;
    using System.Linq;
    
 	// EzPL8.com is the company I work for, hence the namespace root. 
        // EzPL8 increases the brainwidths of waiters and bartenders by augmenting their "memories" with the identifies of customers by name and their food and drink preferences.
       // This is pedagogical example of generating a select option display for a customer's egg preference.  
 
    namespace EzPL8.Models     
    {
        public class MyEggs    
        {
            public Dictionary<int, string> Egg { get; set; }
            public MyEggs()  //constructor
            {
                Egg = new Dictionary<int, string>()
                {
                    { 0, "No Preference"},  //show the complete egg menu to customers
                    { 1, "I hate eggs"},    //Either offer an alternative to eggs or don't show eggs on a customer's personalized dynamically generated menu
                    //confirm with the customer if they want their eggs cooked their usual preferred way, i.e.
                    { 2, "Over Easy"},  
                    { 3, "Sunny Side Up"},
                    { 4, "Scrambled"},
                    { 5, "Hard Boiled"},
                    { 6, "Eggs Benedict"}
                };
        }
    }
