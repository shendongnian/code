    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Appointment
    {
        public int Id { get; set; }
        public string Subject { get; set; }
    }
    public class Participation
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public int AppointmentId { get; set; }
    }
    static void Main(string[] args)
    {
        // Example-Data (Would have helped in this format ;))
        List<People> people = new List<People>()
        {
            new People() { Id = 1, Surname = "David1", Name = "David"},
            new People() { Id = 2, Surname = "Ameyy2", Name = "Ameyy"}
        };
        List<Appointment> appointments = new List<Appointment>()
        {
            new Appointment() { Id = 1, Subject = "description" }
        };
        List<Participation> participations = new List<Participation>()
        {
            new Participation() { Id = 1, PeopleId = 1, AppointmentId = 1 },
            new Participation() { Id = 1, PeopleId = 2, AppointmentId = 1 }
        };
        Console.WriteLine("***** JOIN appointment to participation *****");
        // At the beginning we want to join the table 'Appointment' with the n-to-n-Table "Participation".
        var AppointmentsAndParticipations = appointments.Join
        (
            participations, // Other table to connect
            a => a.Id, // Key in 1st table
            p => p.AppointmentId, // Key in 2nd table
            (a, p) => new { Appointment = a, PeopleId = p.PeopleId } // build new row
        );
        foreach (var item in AppointmentsAndParticipations)
        {
            // The result should be out appointment and the peopleId. We got "Appointment.Count*Participations.Count" rows
            Console.WriteLine(item.Appointment.Id.ToString().PadLeft(5) + ", " + item.Appointment.Subject.PadLeft(15) + ", " + item.PeopleId);
        }
        Console.WriteLine("***** JOIN people *****");
        // We need to join the people which belong to the Ids in participation
        var AppointmentsAndPeople = AppointmentsAndParticipations.Join
        (
            people, a => a.PeopleId, // Similar to 1st join...
            p => p.Id,
            (a, p) => new { Appointment = a.Appointment, People = p }
        );
        foreach (var item in AppointmentsAndPeople)
        {
            Console.WriteLine(item.Appointment.Id.ToString().PadLeft(5) + ", " + item.Appointment.Subject.PadLeft(15) + ", " + item.People.Name + " " + item.People.Surname);
        }
        Console.WriteLine("***** Group the rows *****");
        // Now we want to group the rows back to Appointment-Level. We group by Appointment and People will be out elements to be sum-up
        var AppointmentPools = AppointmentsAndPeople.GroupBy
        (
            key => key.Appointment, // Select the 'column' which shall be the keys
            group => group.People, // Select the 'column' which will be converted to a single value (like count, sum, max ..or in your case string.join())
            (key, group) => new // Build the output object..
            {
                Id = key.Id,
                Subject = key.Subject,
                Participants = string.Join(", ", group.Select(s => s.Name + " " + s.Surname))
            }
        );
        foreach (var item in AppointmentPools)
        {
            Console.WriteLine("Id: " + item.Id + ", Subject: " + item.Subject + ", Participants: " + item.Participants);
        }
    }
