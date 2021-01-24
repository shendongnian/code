    [System.Web.Http.HttpGet]
    [System.Web.Http.ActionName(nameof(GetPrestations))]
    public HttpResponseMessage GetPrestations()
    {
                // var result db.Prestations.ToList();
                var result = new List<Prestations>()
            {
                new Prestations(){
                    IdPrestation = 3,
                    NomPrestation = "blah1"
                },
                new Prestations(){
                    IdPrestation = 4,
                    NomPrestation = "blah2"
                }
            };
        return Request.CreateResponse(HttpStatusCode.OK, result);
    }
    
    public class Prestations
    {
        public int IdPrestation { get; set; }
    
        public string NomPrestation { get; set; }
    }
