    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Hl7.Fhir.Model;
    using Hl7.Fhir.Rest;
    using Hl7.Fhir.Serialization;
    using Newtonsoft.Json.Linq;
    namespace FIHR.Controllers
    {
        [Route("")]
        public class HomeController : Controller
        {
            public string Index()
            {
                return "Welkom op de FIHR API";
            }
            [Route("Patient/rvrbk")]
            public JsonResult ServeClient()
            {
                Patient patient = new Patient();
                patient.Id = "1";
                patient.Gender = AdministrativeGender.Male;
                patient.Name = new List<HumanName> { new HumanName { Family = "Verbeek", Given = new List<string> { "Rik" }, Suffix = new List<string> { "The Small" } } };
                patient.BirthDate = "2004-03-10";
                patient.Active = true;
                FhirJsonSerializer serializer = new FhirJsonSerializer();
                string jstring = serializer.SerializeToString(patient);
                return Json(JObject.Parse(jstring));
            }
            [Route("get")]
            public Patient GetClient()
            {
                FhirClient client = new FhirClient("http://localhost:54240/"); // http://vonk.fire.ly
                Patient patient = client.Read<Patient>("Patient/rvrbk"); // Patient/example
                return patient;
            }
        }
    }
