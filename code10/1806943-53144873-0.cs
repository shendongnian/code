    HttpResponseMessage response = await client.PostAsJsonAsync("RESOURCE", transactionbuilder); 
                var content = await response.Content.ReadAsStringAsync(); 
                dynamic formattedContent = JsonConvert.DeserializeObject<dynamic>(content); 
                var OrderPaymentId = formattedContent.Payment.PaymentId;
                var OrderInstallments = formattedContent.Payment.Installments;
                var OrderCapturedDate = formattedContent.Payment.CapturedDate;
                Console.WriteLine($"" +
                    $"GUID: {OrderPaymentId}\n" +
                    $"Quantidade de Parcelas: {OrderInstallments}\n" +
                    $"Data de captura: {OrderCapturedDate}");
