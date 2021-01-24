    public async Task<IActionResult> Submit(string signalRconnectionId, Dictionary<string, string> inputs)
        {
            
            //Invoke signal to specified client WORKS NOW
            await _signalHubContext.Clients.Client(signalRconnectionId).SendAsync("initSignal", "This is a message from server to this client: " + signalRconnectionId);
            return RedirectToAction("Success", inputs);
        }
