        public override string GetVaryByCustomString(HttpContext context,   
                                              string varyByCustomTypeArg)
        {
            //for a POST request (postback) force to return back a non cached output   
            if (context.Request.RequestType.Equals("POST"))   
            {   
                return "post" + DateTime.Now.Ticks;   
            }
            Type type = Type.GetType("OutputCacheVaryBy" + varyByCustomTypeArg, false)
            if (type == null)
            {
                Console.WriteLine("Failed to find a cache of type " + varyByCustomTypeArg);
                return null;
            }
            var cache = (IOutputCacheVaryByCustom)Activator.CreateInstance(type, new object[]{context});
            return context.Request.Url.Scheme + cache.CacheKey;
        } 
