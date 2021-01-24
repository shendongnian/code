            var viewModel = from plan in myPlannings
                group plan by new
                {
                    plan.StartBlock,
                    plan.StopBlock
                }
                into f
                select new GroupedPlanningViewModel()
                {
                    FromDate = f.Key.StartBlock,
                    StopDate = f.Key.StopBlock,
                    Planning = f.ToList()
                };
            return View(viewModel);
