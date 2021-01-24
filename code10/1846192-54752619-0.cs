    public IHttpActionResult Create([FromBody]USERDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                byte[] saltValue;
                string error = string.Empty;
                saltValue = GenerateSalt();
                dto.INITIALIZER = GetHexStringFromBytes(saltValue);
                dto.PASSWORD = HashPassword(dto.PASSWORD, saltValue, ref error);
                USERDto created = USERSProcessor.Create(dto);
                if (created == null)
                {
                    return NotFound();
                }
                return Ok(created);
            }
            catch (Exception ex)
            {
                LogUtility.LogError(ex);
                return InternalServerError(ex);
            }
        }
