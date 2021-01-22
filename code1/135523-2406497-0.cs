        /// <summary>
        /// Field bound at runtime to a delegate of the method <c>OnPropertyChanged</c>.
        /// </summary>
        [ImportMember("OnPropertyChanged", IsRequired = true, Order = ImportMemberOrder.AfterIntroductions)]
        public Action<string> OnPropertyChangedMethod;
