    public List<ViewModel> toViewModel(List<Entity> entityList) {
            List<ViewModel> response = new ArrayList();
            for (Entity entity : entityList) {
                ViewModel viewModel = entity.convertToViewModel();
                response.add(viewModel);                
            }
            return response;
        }
