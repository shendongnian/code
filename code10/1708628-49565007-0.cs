        [NotMapped]
        [Display(Name = "Fire Type")]
        public Enums.FireType Type
        {
            get
            {
                Enums.FireType type;
                if (!Enum.TryParse(_fireType, out type))
                    type = Enums.FireType.Fire; // default
                return type;
            }
            set
            {
                _fireType = value.ToString();
            }
        }
        
        private string _fireType;
