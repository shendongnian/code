    {
       //--get particular data from dbContext 
       var _address = unitOfWork.AddressRepository.GetById(address.AddressId);
       Mapper.CreateMap<Data.Concrete.Address, Data.Concrete.Address>();
       //--update that particular object via autoMapper
       var _customAddress = Mapper.Map<Address, Address>(address, _address);
           if (unitOfWork.AddressRepository.DataSet.Where(x => x.AddressId == address.AddressId).ToList().Count() > 0)
              unitOfWork.AddressRepository.Update(_customAddress);
           else
              unitOfWork.AddressRepository.Create(address);
    }
