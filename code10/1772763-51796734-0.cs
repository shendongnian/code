    private List<string> MakeCustomDataReadyForPromotion()
        {
            var setting = SettingsDbManager.Instance.GetSettingBaseOnTrackId(Settings.PromotionDetailsTrackId);
            var restaurantTitle = setting.PromotionTitle;
            var promotionBody = setting.PromotionBody;
            var totalCharacters = promotionBody.Length;
            List<string> message = new List<string>
            {
                restaurantTitle
            };
            for (int i = 0; i < totalCharacters; i += 100)
            {
                try
                {
                    message.Add(promotionBody.Substring(i, 100));
                }
                catch
                {
                    message.Add(promotionBody.Substring(i, totalCharacters - i));
                }
            }
            return message;
        }
