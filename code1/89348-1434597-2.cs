    public static class DescriptionExtensions
    {
        public static void AddDescription<THasDescription, TDescription>(
                this THasDescription subject,
                TDescription description)
            where THasDescription : IHasDescription<THasDescription, TDescription>
            where TDescription : IDescription<THasDescription>
        {
            subject.Descriptions.Add(description);
        }
    }
