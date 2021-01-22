     public static CategoryAttribute Appearance
        {
            get
            {
                if (appearance == null)
                {
                    appearance = new CategoryAttribute("Appearance");
                }
                return appearance;
            }
        }
