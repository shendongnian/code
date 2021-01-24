    if (response.IsSuccessStatusCode)
    {
        result = response.Content.ReadAsStringAsync().Result;
        ExchangeRatesResponse datalist = ParseAndReturnExchangeRateItem(result);
        return Json(new { Message = "Your Transaction Has Been Completed Successfully!" }, JsonRequestBehavior.AllowGet);
    }
