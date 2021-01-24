    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Sheets.v4;
    using Google.Apis.Sheets.v4.Data;
    using System;
    using System.IO;
    using System.Threading;
    using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.UpdateRequest;
    
    class Program
    {
        static void Main(string[] args)
        {
            // Set-up part...
            if (args.Length != 4)
            {
                Console.WriteLine("Required values: <client secrets file> <spreadsheet-ID> <cell> <formula>");
                Console.WriteLine("Example: <secrets.json> <sheet ID> E1 =MAX(A1:D1)");
                return;
            }
            var secretsFile = args[0];
            var spreadsheetId = args[1];
            var cell = args[2];
            var formula = args[3];
    
            var secrets = File.ReadAllBytes(secretsFile);
    
            // Don't usually use Task<T>.Result, but this is just a demo console app...
            // we shouldn't have any deadlock worries.
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new MemoryStream(secrets),
                new[] { SheetsService.Scope.Spreadsheets },
                "user", // Key in file store
                CancellationToken.None).Result;
    
            var service = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Sheets API demo"
            });
    
            // Interesting bit :)
            var valueRange = new ValueRange { Values = new[] { new object[] { formula } } };
            var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, cell);
            // Pretend we're a user typing in this value...
            request.ValueInputOption = ValueInputOptionEnum.USERENTERED;
            // Get the computed value back in the response
            request.IncludeValuesInResponse = true;
            // Retrieve the value unformatted (so as a number in the JSON)
            // rather than either the uncomputed value, or the formatted value as a string
            request.ResponseValueRenderOption = ResponseValueRenderOptionEnum.UNFORMATTEDVALUE;
            var response = request.Execute();
            Console.WriteLine($"Result: {response.UpdatedData.Values[0][0]}");
        }
    }
