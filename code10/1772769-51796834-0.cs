    private List<string> MakeCustomDataReadyForPromotion()
        {
            // etc etc
            /// etc etc
            AddMessage(promotionBody, message);
        }
        private static void AddMessage(AddInCorrectObjectHere promotionBody, List<string> message)
        {
            for (int i = 0; i < Math.Ceiling((decimal)promotionBody.Length / 100); i++)
            {
                message.Add(promotionBody.Substring(i, (i + 1) * 100 - 1));
            }
        }
