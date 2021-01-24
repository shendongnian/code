    var form = new MultipartFormDataContent(); //'multipart/form-data'
    //<input name ="VSS_SERV" value="ZVWSBJXML"> 
    form.Add(new StringContent("ZVWSBJXML"), "VSS_SERV"); 
    var xml = @"<?xml version=""1.0"" encoding=""ISO-8859-2""?>
    <VerejnyWebDotaz 
        xmlns=""urn:cz:isvs:rzp:schemas:VerejnaCast:v1"" 
        version=""2.8"">
        <Kriteria> 
            <IdentifikacniCislo>03358437</IdentifikacniCislo> 
            <PlatnostZaznamu>0</PlatnostZaznamu>
        </Kriteria>
    </VerejnyWebDotaz>";
    var doc = XDocument.Parse(xml);
    var stream = new MemoryStream();
    doc.Save(stream);
    stream.Position = 0;
    //<input type="file" name="filename"> 
    form.Add(new StreamContent(stream), "filename", "req-detail.xml");
    var client = new HttpClient();
    client.BaseAddress = new Uri("http://www.rzp.cz/cgi-bin/aps_cacheWEB.sh");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
    var response = await client.PostAsync("", form);
    var responseContent = await response.Content.ReadAsStringAsync();
