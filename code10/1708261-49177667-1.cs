        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _unitOfWork.Customers.GetCustomerById(id);
            return Ok(Mapper.Map<CustomerViewModel>(customer));
        }
