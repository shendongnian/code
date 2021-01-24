    public async Task<bool> GetAllPharmacies()
    {
        try
        {
            var client = new HttpClient();
            var uri = "http://no-nonsense-caliber.000webhostapp.com/ajax/GetAllPharmacies.php";
            string result = await client.GetStringAsync(uri);
            var pharms = JsonConvert.DeserializeObject<List<Model1>>(result);
            foreach (Model1 pharm in pharms)
            {
                AddNewPharmacy(pharm.name, pharm.address, pharm.phone, pharm.email, pharm.dp, pharm.gmap, pharm.city);
            }
        }
        catch (Exception ex)
        {
            Toast.MakeText(this, ex.Message, ToastLength.Long);
        }
        return true;
    }
