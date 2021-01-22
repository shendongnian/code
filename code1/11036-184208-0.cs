        public void DoSomething<G>(G generic)
            where G : ElementDefinition
        {
            DetailElement detail = generic as DetailElement;
            if (detail != null)
            {
                detail.DescEN = "Hello people";
            }
            else
            {
                //do other stuff
            }
        }
