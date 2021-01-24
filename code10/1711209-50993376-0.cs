    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Hl7.Fhir.Serialization;
    using Hl7.Fhir.Model;
            string url = "https://www.somebody.com/FHIR/api/Patient?given=Jason&family=Smith";
            HttpClient client = new HttpClient();
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string responseString = await content.ReadAsStringAsync();
                        response.EnsureSuccessStatusCode();
                        /* Hl7.Fhir.DSTU2  \.nuget\packages\hl7.fhir.dstu2\0.96.0 */
                        FhirJsonParser fjp = new FhirJsonParser(); /* there is a FhirXmlParser as well */
                        /* You may need to Parse as something besides a Bundle depending on the return payload */
                        Hl7.Fhir.Model.Bundle bund = fjp.Parse<Hl7.Fhir.Model.Bundle>(responseString);
                        if (null != bund)
                        {
                            Hl7.Fhir.Model.Bundle.EntryComponent ec = bund.Entry.FirstOrDefault();
                            if (null != ec && null != ec.Resource)
                            {
                                /* again, this may be a different kind of object based on which rest url you hit */
                                Hl7.Fhir.Model.Patient pat = ec.Resource as Hl7.Fhir.Model.Patient;
                            }
                        }
                    }
                }
            }
