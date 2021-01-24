    using System.Collections;
    using UnityEngine;
    
    public class MoveCanvas : MonoBehaviour
    {
        private Vector3 _reset = new Vector3(0, 0, -10);
        private Vector3 _leftpanel = new Vector3(-205.5f, 0, 0);
        private Vector3 _rightpanel = new Vector3(205.5f, 0, 0);
        private float _smoothTime = 0.7f;
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _currentposition;
        private int _stoplimit = 2;
    
        void Start()
        {
            _currentposition = gameObject.transform.position;
        }
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(GoLeft());
            }
            
            else if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(GoRight());
            }
        }
    
        private IEnumerator GoLeft()
        {
            if (_currentposition == _reset)
            {
                while (!Mathf.Approximately(_currentposition.x, _leftpanel.x))
                {
                    gameObject.transform.position = Vector3.SmoothDamp(_currentposition, _leftpanel, ref _velocity, _smoothTime);
                    _currentposition = gameObject.transform.position;
                    if (Mathf.Abs((_currentposition.x) - (_leftpanel.x)) < _stoplimit)
                    {
                        break;
                    }
                    yield return new WaitForEndOfFrame();
                }
                gameObject.transform.position = _leftpanel;
                _currentposition = _leftpanel;
                
            }
    
            else if (_currentposition == _rightpanel)
            {
                while (!Mathf.Approximately(_currentposition.x, _reset.x))
                {
                    gameObject.transform.position = Vector3.SmoothDamp(_currentposition, _reset, ref _velocity, _smoothTime);
                    _currentposition = gameObject.transform.position;
                    if (Mathf.Abs((_currentposition.x) - (_reset.x)) < _stoplimit)
                    {
                        break;
                    }
                    yield return new WaitForEndOfFrame();
                }
                gameObject.transform.position = _reset;
                _currentposition = _reset;
                
            }
        }
    
        private IEnumerator GoRight()
        {
            if (_currentposition == _reset)
            {
                while (!Mathf.Approximately(_currentposition.x, _rightpanel.x))
                {
                    gameObject.transform.position = Vector3.SmoothDamp(_currentposition, _rightpanel, ref _velocity, _smoothTime);
                    _currentposition = gameObject.transform.position;
                    if (Mathf.Abs((_currentposition.x) - (_rightpanel.x)) < _stoplimit)
                    {
                        break;
                    }
                    yield return new WaitForEndOfFrame();
                }
                gameObject.transform.position = _rightpanel;
                _currentposition = _rightpanel;
                
            }
            else if (_currentposition == _leftpanel)
            {
                while (!Mathf.Approximately(_currentposition.x, _reset.x))
                {
                    gameObject.transform.position = Vector3.SmoothDamp(_currentposition, _reset, ref _velocity, _smoothTime);
                    _currentposition = gameObject.transform.position;
                    if (Mathf.Abs((_currentposition.x) - (_reset.x)) < _stoplimit)
                    {
                        break;
                    }
                    yield return new WaitForEndOfFrame();
                }
                gameObject.transform.position = _reset;
                _currentposition = _reset;
               
    
            }
        }
    
    }
