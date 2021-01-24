    public async Task<IActionResult> OnGetAsync(int? id)
    {
      // this "reads" better
      if (id.HasValue)
      {
        return NotFound();
      }
      VIndividualCustomer = await _context.VIndividualCustomer
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.BusinessEntityId == id);
      if (VIndividualCustomer == null)
      {
        return NotFound();
      }
      query = VIndividualCustomer.AddressLine1 + " " +
        VIndividualCustomer.AddressLine2 + ", " +
        VIndividualCustomer.City + ", " +
        VIndividualCustomer.StateProvinceName + ", " +
        VIndividualCustomer.PostalCode;
      query = "1 Microsoft Way, Redmond, WA";
      // string interpolation
      //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
      var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={query}&key={BingMapKey}";
      var geocodeRequest = new Uri(url);
      var ser = new DataContractJsonSerializer(typeof(Response));
 
      var response = await (new HttpClient()).GetAsync(geocodeRequest);
      var json = await response.Content.ReadAsStringAsync();
      var x = ser.ReadObject(json) as Response;     
      var location = (BingMapsRESTToolkit.Location)x.ResourceSets[0].Resources[0];
      latitude = location.GeocodePoints[0].Coordinates[0];
      longitude = location.GeocodePoints[0].Coordinates[1];
      return Page();
    }
