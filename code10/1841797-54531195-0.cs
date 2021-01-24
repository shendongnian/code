        [Route("graph/[controller]")]
        public class GraphController : ControllerBase
        {
            /// <summary>
            /// Retrieve configured AAD Users
            /// </summary>
            /// <returns>An awaitable <seealso cref="Task{ICollection{AADUser}}>}"/>that contains a mapping of Ids of Users and their mapped Groups</returns>
            [Route("Users")]
            [HttpGet]
            public async Task<IActionResult> GetUsersAsync()
            {
                ICollection<AADUser> response;
                try
                {
                    response = await graphBC.GetUsersAsync().ConfigureAwait(false);
                    if (response == null || response.Count < 1)
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Ok(response);
            } 
