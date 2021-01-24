        [Template(TemplateUsage.EnumSelectOne, "Please choose a pizza {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        [Describe("Pizza")]
        public Pizza PizOption;
        [Template(TemplateUsage.EnumSelectOne, "Please choose a dessert {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        [Describe("Desert")]
        public Dessert? DesOption;
