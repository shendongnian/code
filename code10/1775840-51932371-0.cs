    void Update()
        {
                StateManager sm = TrackerManager.Instance.GetStateManager();
                IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();
                foreach (TrackableBehaviour tb in tbs)
                {
                    string name = tb.TrackableName;
                    ImageTarget it = tb.Trackable as ImageTarget;
                    Vector2 size = it.GetSize();
                    Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " 
                    + size.y);
                    ButtonAction.gameObject.SetActive(true);
                    TextDescription.gameObject.SetActive(true);
                    PanelDescription.gameObject.SetActive(true);
                    ButtonMute.gameObject.SetActive(true);
                    if (name == "quezon")
                    {
                        ButtonAction.GetComponent<Button>().onClick.AddListener(delegate
                        {
                            if (soundTarget.isPlaying)
                            {
                                soundTarget.Pause();
                                btn.image.overrideSprite = Play;
                            }
                            else
                            {
                                btn.image.overrideSprite = Pause;
                                playSound("sounds/English");
                                soundTarget.Play();
                            }
                        });
                    TextDescription.GetComponent<Text>().text = "Manuel L. Quezon was 
                    born on August 19, 1878, and died on August 1, 1944. He was a 
                    Filipino statesman, soldier, and politician who served as president 
                    of the Commonwealth of the Philippines from 1935 to 1944.";
                    Narrator.gameObject.SetActive(true);
                    void playSound(string ss)
                         {
                           clipTarget = (AudioClip)Resources.Load(ss);
                           soundTarget.clip = clipTarget;
                           soundTarget.loop = false;
                           soundTarget.playOnAwake = false;     
                           soundTarget.ignoreListenerPause = true;
                         }
