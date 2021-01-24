           public ActionResult Index(string SortOrder, int? page, string ProgrammeIdSelected)
        {
            IndexViewModel model = new IndexViewModel();
            //Affichage de la liste des Programmes
            model.Programme = GetProgrammes();
            //Tri des pays:
            model.SortCountry = String.IsNullOrEmpty(SortOrder) ? "ListorderPays_desc" : "";
            model.ProgrammeIdSelected = ProgrammeIdSelected;
            model.missionsList = db.missions_supportmission.ToList();
            switch (SortOrder)
            {
                case "ListorderPays_desc":
                    model.missionsList = model.missionsList.OrderByDescending(s => s.organization_hi_country.name_en);
                    break;
                default:
                    model.missionsList = model.missionsList.OrderBy(s => s.organization_hi_country.name_en);
                    break;
            }
            //Pagination
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfMissions = model.missionsList.ToPagedList(pageNumber, 10); // will only contain 10 products max because of the pageSize(equel to 10)
            model.OnePageOfMissions = onePageOfMissions;
                //Ischecked
            var allDecisions = db.list_decision.ToList();//returns List<list_decision>
            var checkBoxListItems = new List<CheckBoxListItem>(); //nouvelle instance de la classe checkboxlist
            foreach (var decison in allDecisions)
            {//On assigne les valeurs "id", "display" et "is checked" à la variable checkboxlistitem
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = decison.decision_id,
                    Display = decison.name_en,
                    IsChecked = false //On the add view, no decision are selected by default
                });
            }
             
            //Si Programme n'est pas null et que country est null
            if (!String.IsNullOrEmpty(ProgrammeIdSelected))
            {
                model.OnePageOfMissions = db.missions_supportmission
                                .Where(a => a.programme_id == ProgrammeIdSelected)
                                .OrderBy(a => a.programme_id)
                                .Select(s => s).ToPagedList(pageNumber, 10);
            }
            return View(model);
        }
