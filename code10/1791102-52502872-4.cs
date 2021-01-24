    public static List<QuizItem> GetQuizItems()
    {
        return new List<QuizItem>
        {
            new QuizItem
            {
                Question = "The fuselage is the center structure of an aircraft and " + 
                    "provides the connection for the wings and tail.",
                Choices = new List<string> {"True", "False"},
                CorrectChoiceIndex = 0
            },
            new QuizItem
            {
                Question = "Rolling is the action on the lateral axis of an aircraft.",
                Choices = new List<string> {"True", "False"},
                CorrectChoiceIndex = 0
            },
            new QuizItem
            {
                Question = "Drag is the name of the force that resists movement of an  " + 
                    "aircraft through the air.",
                Choices = new List<string> {"True", "False"},
                CorrectChoiceIndex = 0
            },
            new QuizItem
            {
                Question = "Flaps are attached to the trailing edge of a wing structure  " + 
                    "and only increases drag.",
                Choices = new List<string> {"True", "False"},
                CorrectChoiceIndex = 1
            },
            new QuizItem
            {
                Question = "Powerplant or engine produces thrust to propel an aircraft.",
                Choices = new List<string> {"True", "False"},
                CorrectChoiceIndex = 0
            },
            new QuizItem
            {
                Question = "Which of the following are part of an aircraft " + 
                    "primary flight controls?",
                Choices = new List<string>
                    {"Aileron", "Rudder", "Elevators", "All of the above"},
                CorrectChoiceIndex = 3
            },
            new QuizItem
            {
                Question = "The Fuel-air control unit of a reciprocating engine?",
                Choices = new List<string>
                    {
                        "Sends fuel to the piston chamber",
                        "Sends air to the piston chamber",
                        "Controls the mixture of air and fuel",
                        "Meters the quantity of fuel"
                    },
                CorrectChoiceIndex = 2
            },
            new QuizItem
            {
                Question = "Which of the following is the main source of electrical power " + 
                    "when starting an aircraft?",
                Choices = new List<string> 
                    {"Primary Bus", "Avionics Bus", "Battery", "GPU (ground power unit)"},
                CorrectChoiceIndex = 2
            },
            new QuizItem
            {
                Question = "The reservoir of a hydraulic system is used for what?",
                Choices = new List<string>
                    {
                        "Store and collect fluid from a hydraulic system",
                        "Lubricate components when needed",
                        "Keep the fluid clean",
                        "All of the above"
                    },
                CorrectChoiceIndex = 0
            },
            new QuizItem
            {
                Question = "Flying into fog can cause what?",
                Choices = new List<string>
                    {
                        "Narrowing of the runway",
                        "An aircraft to stall",
                        "An illusion of pitching up",
                        "A stressful environment for the Pilot and Co-pilot"
                    },
                CorrectChoiceIndex = 2
            }
        };
    }
