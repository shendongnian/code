    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    namespace WebApplication1.Pages
    {
        public class LoginModel : PageModel
        {
            [BindProperty]
            public string UserName { get; set; }
            [BindProperty]
            public string Password { get; set; }
            public bool IsloggedIn { get; private set; }
            public void OnPost()
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres; Password = postgres; Database = login; ");
                // Open Database connection.
                conn.Open();
                // Define a query returning a single row result set.
                NpgsqlCommand command = new NpgsqlCommand("SELECT username, password FROM logindata WHERE username = @username AND password = @password", conn);
                command.Parameters.AddWithValue("@username", UserName);
                command.Parameters.AddWithValue("@password", Password);
                // Execute the query and obtain a result set.
                NpgsqlDataReader dr = command.ExecuteReader();
                // If result exists return true and gain access to the control website.
                if (dr.Read())
                {
                    IsloggedIn = true;
                }
                // Close Database connection.
                conn.Close();
            }
        }
    }
