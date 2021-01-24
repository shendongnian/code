    [TypeFilter(typeof(AuthorizeFilter), 
        Arguments = new object[] {
            new string[] { PolicyName.CanUpdateModule,  PolicyName.CanReadModule }
        }
    )]
    public async Task<IActionResult> PutModule([FromRoute] Guid id, [FromBody] Module module) {
        /*do stuff*/
    }
