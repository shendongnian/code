    private List<string> MakeCustomDataReadyForPromotion() {
        var setting = SettingsDbManager.Instance.GetSettingBaseOnTrackId(Settings.PromotionDetailsTrackId);
        var restaurantTitle = setting.PromotionTitle;
        var promotionBody = setting.PromotionBody;
        int chunkSize = 100;
        List<string> message = new List<string> {
            restaurantTitle
        };
        for (int i = 0; i < promotionBody.Length; i += chunkSize) {
            if (promotionBody.Length - i >= chunkSize)
                message.Add(promotionBody.Substring(i, chunkSize));
            else
                message.Add(promotionBody.Substring(i, promotionBody.Length - i));
        }
        return message;
    }
