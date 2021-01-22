    string userName = "John Doe";
    var mailBody = new HTML {
        new H(1) {
            "Heading Here"
        },
        new P {
            string.Format("Dear {0},", userName),
            new Br()
        },
        new P {
            "First part of the email body goes here"
        }
    };
    string htmlString = mailBody.Render();
