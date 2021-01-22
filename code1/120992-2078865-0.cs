    View Model code:
            [DisplayName("Criterion Type")]
            public virtual CriterionType[] CriterionTypes { get; set; }
            [DisplayName("Criterion Type")]
            public SelectList CriterionTypeList
            {
                get
                {
                    return new SelectList(CriterionTypes, "Id", "Key");
                }
            }  
