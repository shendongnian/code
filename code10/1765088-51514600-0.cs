    var result = JsonConvert.DeserializeObject<IEnumerable<JObject>>(json)
        .Select(jobj =>
        {
            var cdr = jobj.TryGetValue("cdr", out var token) ? token.ToObject<string>() : null;
            var mainCdr = jobj.TryGetValue("main_cdr", out token) ? token.ToObject<Cdr>() : null;
            var subCdrs = new List<Cdr>();
            for (var i = 1; jobj.TryGetValue("sub_cdr_" + i, out token); i++)
                subCdrs.Add(token.ToObject<Cdr>());
            return new
            {
                Cdr = cdr, // string
                MainCdr = mainCdr, // Cdr
                SubCdrs = subCdrs // List<Cdr>
            };
        })
        .ToList();
