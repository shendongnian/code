        public static void SanitizeWildcards( Controller controller, params string[] filterStrings )
        {
            foreach( var filterString in filterStrings )
            {
                var modelState = controller.ModelState;
                ModelState modelStateValue;
                if( modelState.TryGetValue(filterString,out 
                        controller.ModelState.SetModelValue(filterString, new ValueProviderResult("","", null));
            }
        }
