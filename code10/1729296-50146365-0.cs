            CreateMap<SavePatientsRegistryViewModel, PatientRegistry> ()
                .ForMember (d => d.RecordId, opt => opt.Ignore ())
                .ForMember (d => d.PatientFileId, opt => opt.Ignore ())
                .ForMember (d => d.UserId, opt => opt.Ignore ())
                .ForMember (d => d.Partners, opt => opt.Ignore ())
                .ForMember (d => d.User, opt => opt.MapFrom (s => s.OnlineAccount))
                .AfterMap ((s, d) => {
    // check if context object is included in the model? if not prime for delete.
                    foreach (PartnerRegistry partner in d.Partners.ToList ()) {
                        SavePartnerRegistryViewModel modelPartner = s.Partners.SingleOrDefault (c => c.PatientFileId == partner.PatientFileId && c.PartnerFileId == partner.PartnerFileId);
                        if (!s.Partners.Contains (modelPartner)) {
                            d.Partners.Remove (partner);
                        }
                    }
    // check if model object(s) is/are included in the context? 
                    foreach (SavePartnerRegistryViewModel modelPartner in s.Partners) {
                        PartnerRegistry partner = d.Partners.SingleOrDefault (c => c.PatientFileId == modelPartner.PatientFileId && c.PartnerFileId == modelPartner.PartnerFileId);
    // if yes, prime for update
                        if (d.Partners.Contains (partner)) {
                            partner.PartnerFileId = modelPartner.PartnerFileId;
                            partner.StartDate = DateTime.Parse (modelPartner.StartDate);
                            partner.EndDate = string.IsNullOrWhiteSpace (modelPartner.EndDate) ? (DateTime?) null : DateTime.Parse (modelPartner.EndDate);
                        } else {
    // if Not, prime for insert
                            d.Partners.Add (
                                new PartnerRegistry {
                                    PatientFileId = modelPartner.PatientFileId,
                                        PartnerFileId = modelPartner.PartnerFileId,
                                        StartDate = DateTime.Parse (modelPartner.StartDate),
                                        EndDate = string.IsNullOrWhiteSpace (modelPartner.EndDate) ? (DateTime?) null : DateTime.Parse (modelPartner.EndDate)
                                }
                            );
                        }
                    }
                });
