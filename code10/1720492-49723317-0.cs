    var subscriber = new Dictionary<string, string>() {
                {"+3912345678", "John"},
                {"+3917564237", "Mark"},
                {"+3915765311", "Ester"}
            };
    // Iterate over subscribers
    foreach (var person in subscriber)
    {
        // Send a new outgoing SMS by POSTing to the Messages resource
        MessageResource.Create(
            from: new PhoneNumber("555-555-5555"), // From number, must be an SMS-enabled Twilio number
            to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
            // Message content
            body: $"Hello {person.Value}");
    
        Console.WriteLine($"Sent message to {person.Value}");
    } 
