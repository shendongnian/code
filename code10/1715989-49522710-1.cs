    public class Controller{
       Model _model;
       View _view;
       Mapper _mapper;
    
       public Controller(){
          _model=new Model();
          _view=new View();
          _mapper = new ViewModelMapper();
    
       }
    
       public void SetContentView(){
          _view.SetContent(_mapper.map(_model));
       }
    } 
