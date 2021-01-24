    static class DataTableExtensions
    {
         public static IEnumerable<Customer> ToCustomers(this DataTable table)
         {
              ... // TODO: implement
         }
         public static DataTable ToDataTable(this IEnumerable<Customer> customers)
         {
              ... // TODO implement
         }
         // similar functions for Appointments and AppointmentDetails:
         public static IEnumerable<Appointment> ToAppointments(this DataTable table) {...}
         public static DataTable ToDataTable(this IEnumerable<Appointment> appointments) {...}
         public static IEnumerable<AppointmentDetails> ToAppointmentDetails(this DataTable table) {...}
         public static DataTable ToDataTable(this IEnumerable<AppointmentDetail> appointmentDetails) {...}
      
