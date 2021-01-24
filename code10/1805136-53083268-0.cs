    using MyHR.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using static MyHR.Domain.Models.CurrencyDataSet;
    
    namespace MyHR.Web.Controllers
    {
        public class ExchangeRateController : Controller
        {
    
            //        // GET: ExchangeRate
    
    
            public ActionResult ExchangeRate(List<ExchangeRate> data)
            {
    
                {
                    data = new List<ExchangeRate>();
    
                    data = exchangeRates();
    
                    return View(data);
                }
    
    
    
            }
            public List<ExchangeRate> exchangeRates()
            {
    
                CurrenciesDataSet dataset = null;
                
                List<ExchangeRate> rates = new List<ExchangeRate>();
                XDocument doc = XDocument.Load(@"http://www.bnr.ro/nbrfxrates.xml");
    
                using (TextReader sr = new StringReader(doc.ToString(SaveOptions.DisableFormatting)))
                {
                    var serializer = new XmlSerializer(typeof(CurrenciesDataSet));
                    dataset = (CurrenciesDataSet)serializer.Deserialize(sr);
                }
    
                
                Cube cube = dataset.Body.Cubes.FirstOrDefault();
    
                if (cube != null)
                {
                    rates = cube.Rates.Select(x => new ExchangeRate
                    {
                        DataCurenta = cube.Date,
                        Moneda = x.Currency,
                        Valoarea = x.Multiplier.ToString(),
                    }).ToList();
                }
    
                return rates;
            }
        }
    }
