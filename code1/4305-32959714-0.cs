     // Send a new outgoing MMS by POSTing to the Messages resource */
        client.SendMessage(
            "YYY-YYY-YYYY", // From number, must be an SMS-enabled Twilio number
            person.Key,     // To number, if using Sandbox see note above
            // message content
            string.Format("Hey {0}, Monkey Party at 6PM. Bring Bananas!", person.Value),
            // media url of the image
            new string[] {"https://demo.twilio.com/owl.png" }
        );
