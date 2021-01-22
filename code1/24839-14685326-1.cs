        //Replace "YourEnum" with the type of your enum
        public IEnumerable<SelectListItem> AllItems
        {
            get
            {
                return Enums.GetValues<YourEnum>().Select(enumValue => new SelectListItem { Value = enumValue.ToString(), Text = enumValue.GetDescription() });
            }
        }
