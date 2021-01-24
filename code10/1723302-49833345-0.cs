    using System.Collections.Generic;
    ...
    IDictionary<string, string> queryParams = req.GetQueryNameValuePairs()
        .ToDictionary(x => x.Key, x => x.Value);
    // Use queryParams["fbAppID"] to read keys from the dictionary.
