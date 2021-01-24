    namespace TTTTTest {
        public partial class ParametrosGeometricosViewModel {
            public double DistanciaProjetorParede {
                get => Model.DistanciaProjetorParede;
                set
                {
                    Model.DistanciaProjetorParede = value;
                    RaisePropertyChanged(() => DistanciaProjetorParede);
                }
            }
            public double AlturaProjetor {
                get => Model.AlturaProjetor;
                set
                {
                    Model.AlturaProjetor = value;
                    RaisePropertyChanged(() => AlturaProjetor);
                }
            }
            public double AlturaInferiorProjecao {
                get => Model.AlturaInferiorProjecao;
                set
                {
                    Model.AlturaInferiorProjecao = value;
                    RaisePropertyChanged(() => AlturaInferiorProjecao);
                }
            }
            public double AlturaSuperiorProjecao {
                get => Model.AlturaSuperiorProjecao;
                set
                {
                    Model.AlturaSuperiorProjecao = value;
                    RaisePropertyChanged(() => AlturaSuperiorProjecao);
                }
            }
            public double DistanciaCameraParede {
                get => Model.DistanciaCameraParede;
                set
                {
                    Model.DistanciaCameraParede = value;
                    RaisePropertyChanged(() => DistanciaCameraParede);
                }
            }
            public double AlturaCamera {
                get => Model.AlturaCamera;
                set
                {
                    Model.AlturaCamera = value;
                    RaisePropertyChanged(() => AlturaCamera);
                }
            }
            public double AlturaInferiorImagem {
                get => Model.AlturaInferiorImagem;
                set
                {
                    Model.AlturaInferiorImagem = value;
                    RaisePropertyChanged(() => AlturaInferiorImagem);
                }
            }
            public double AlturaSuperiorImagem {
                get => Model.AlturaSuperiorImagem;
                set
                {
                    Model.AlturaSuperiorImagem = value;
                    RaisePropertyChanged(() => AlturaSuperiorImagem);
                }
            }
        }
    }
