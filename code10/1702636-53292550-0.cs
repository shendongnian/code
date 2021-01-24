    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    namespace Example
    {
    internal class Example
    {
        private static void Main()
        {
            Execute().Wait();
        }
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            var people = new List<Person>
            {
                new Person {FirstName = "First1", LastName = "Last1", Email = "email1@example.com"},
                new Person {FirstName = "First2", LastName = "Last2", Email = "email2@example.com"},
                new Person {FirstName = "First3", LastName = "Last3", Email = "email3@example.com"}
            };
            msg.SetFrom(new EmailAddress("test@example.com", "Example User"));
            msg.SetSubject("Test Subject 1");
            msg.AddContent(MimeType.Text, "Hello -firstname- -lastname-");
            var tos = new List<EmailAddress>();
            var personalizationIndex = 0;
            foreach (var person in people)
            {
                tos.Add(new EmailAddress(person.Email, person.FirstName));
                msg.AddSubstitution("-firstname-", person.FirstName, personalizationIndex);
                msg.AddSubstitution("-lastname-", person.LastName, personalizationIndex);
                personalizationIndex++;
            }
            msg.AddTos(tos);
            var response = await client.SendEmailAsync(msg);
        }
    }
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    }
