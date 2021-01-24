    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    namespace WebApplication3.Controllers
    {
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            // GET api/values
            [HttpGet]
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }
            [HttpGet("{a}/{b}/{c}/{d}/{e}/{f}/{g}/{h}/{i}/{j}/{k}/{l}/{m}/{n}/{o}/{p}/{q}/{r}/{s}/{t}/{u}/{v}/{w}/{x}/{y}/{z}/{a2}/{b2}")]
            public string Get(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r, int s, int t, int u, int v, int w, int x, int y, int z, int a2, int b2) =>
                $"Hello {a} {b} ...";
        }
    }
